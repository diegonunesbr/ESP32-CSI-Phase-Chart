/*
Arduino IDE Version: 1.8.8
ESP32 Add-on Version: 1.0.2
Arduino Board Configuration:
  Board: DOIT ESP32 DEVKIT V1
  Upload Speed: 921600
  Flash Frequency: 80MHz
  Core Debug Level: None 
*/

#include <stdio.h>
#include "freertos/FreeRTOS.h"
#include "freertos/event_groups.h"
#include "esp_wifi.h"
#include "esp_wifi_internal.h"
#include "esp_wifi_types.h"
#include "esp_system.h"
#include "esp_log.h"
#include "esp_event.h"
#include "esp_event_loop.h"
#include "nvs_flash.h"

//uint8_t macAddressToFilter[] = {0x3C, 0x71, 0xBF, 0x8C, 0x30, 0xDD};
//#define WIFI_CHANNEL 6

uint8_t macAddressToFilter[] = {0xD4, 0x6E, 0x0E, 0xB2, 0x23, 0x45};
#define WIFI_CHANNEL 1


esp_err_t event_handler(void *ctx, system_event_t *event) {
  return ESP_OK;
}


void sniffer(void *buf, wifi_promiscuous_pkt_type_t type) {
}


void receive_csi_cb(void *ctx, wifi_csi_info_t *data) {
  if(memcmp(macAddressToFilter, data->mac, 6) != 0) {
    return;
  }

  if(data->len < 128) {
    return;
  }

  int8_t* my_ptr = data->buf;
  // first number is the wifi channel
  Serial.printf("[[[\t%2d\t", WIFI_CHANNEL);
  for(int i = 0; i < 128; i++) {
    Serial.printf("%4d\t", *my_ptr);
    my_ptr++;
  }
  Serial.print("]]]\n");
}


void InitCSI() {
  nvs_flash_init();
  tcpip_adapter_init();

  ESP_ERROR_CHECK(esp_event_loop_init(event_handler, NULL));
  
  wifi_init_config_t cfg = WIFI_INIT_CONFIG_DEFAULT();
  cfg.csi_enable = 1; 

  ESP_ERROR_CHECK(esp_wifi_init(&cfg));
  
  ESP_ERROR_CHECK(esp_wifi_set_storage(WIFI_STORAGE_RAM));

  ESP_ERROR_CHECK(esp_wifi_set_mode(WIFI_MODE_STA));
  ESP_ERROR_CHECK(esp_wifi_start());

  ESP_ERROR_CHECK(esp_wifi_set_promiscuous(true));
  ESP_ERROR_CHECK(esp_wifi_set_promiscuous_rx_cb(&sniffer));

  ESP_ERROR_CHECK(esp_wifi_set_csi(true));

  wifi_csi_config_t configuration_csi;
  configuration_csi.lltf_en = true;
  configuration_csi.htltf_en = true;
  configuration_csi.stbc_htltf2_en = true;
  configuration_csi.ltf_merge_en = true;
  configuration_csi.channel_filter_en = true;
  configuration_csi.manu_scale = false;
  configuration_csi.shift = 0; // 0->15

  ESP_ERROR_CHECK(esp_wifi_set_csi_config(&configuration_csi));
  ESP_ERROR_CHECK(esp_wifi_set_csi_rx_cb(&receive_csi_cb, NULL));

  esp_wifi_set_channel(WIFI_CHANNEL, WIFI_SECOND_CHAN_NONE);
}


void setup() {
  Serial.begin(115200);
  InitCSI();
}


void loop() {
}
