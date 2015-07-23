#include <SoftwareSerial.h>

int bluetoothTx = 17;  // TX-O pin of bluetooth mate, lilypad A2 - orange
int bluetoothRx = 16;  // RX-I pin of bluetooth mate, lilypad A3 - blue

SoftwareSerial bluetooth(bluetoothTx, bluetoothRx);

#define CAMERA_PIN 5
#define POT_PIN 6
#define UMBRELLA_PIN 2  // (analog)

// CAMERA
boolean currCamera = false;
boolean lastCamera = false; // to detect state changes
// POT
boolean currPot = false;
boolean lastPot = false;
// UMBRELLA
int umbrellaLight = 0;
int umbrellaThreshold = 220;  // how much light there needs to be to be "on"/open
boolean currUmbrella = false;
boolean lastUmbrella = false;

void setup() {
  Serial.begin(9600);
  pinMode(CAMERA_PIN, INPUT_PULLUP);
  pinMode(POT_PIN, INPUT_PULLUP);

  // startup bluetooth
  bluetooth.begin(115200);  // The Bluetooth Mate defaults to 115200bps
  bluetooth.print("$");  // Print three times individually
  bluetooth.print("$");
  bluetooth.print("$");  // Enter command mode
  delay(100);  // Short delay, wait for the Mate to send back CMD
  bluetooth.println("U,9600,N");  // Temporarily Change the baudrate to 9600, no parity
  bluetooth.begin(9600);  // Start bluetooth serial at 9600

  Serial.println("ready to revolt");
}

void loop() {
  // get current states
  currCamera = digitalRead(CAMERA_PIN);
  currPot = digitalRead(POT_PIN);
  umbrellaLight = analogRead(UMBRELLA_PIN);

  // check for buttons being pressed (without repeats)
  if (currCamera == LOW and lastCamera == HIGH ) {
    Serial.println("Photo taken");
    bluetooth.println("Photo taken");
  }
  if (currPot == LOW and lastPot == HIGH) {
    Serial.println("Pot bangeed");
    bluetooth.println("Pot bangeed");
  }
  // for the umbrella we check if the light crossed the threshold
  // and if the last state of the umbrella was unopened/false
  if (umbrellaLight > umbrellaThreshold and lastUmbrella == false) {
    currUmbrella = true;  // it's open now, so set state to true
    Serial.println("Umbrella opened");
    bluetooth.println("Umbrella bangeed");
  }
  if (umbrellaLight < umbrellaThreshold) {
    // if it goes under threshold just set it to unopened/false
    currUmbrella = false;
  }

  // new states
  lastCamera = currCamera;
  lastPot = currPot;
  lastUmbrella = currUmbrella;

  //Serial.println(analogRead(2)); //Write the value of the photoresistor to the serial monitor.

  delay(40);
}
