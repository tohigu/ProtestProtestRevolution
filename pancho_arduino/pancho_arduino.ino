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

  Serial.println("ready to revolt");
}

void loop() {
  // get current states
  currCamera = digitalRead(CAMERA_PIN);
  currPot = digitalRead(POT_PIN);
  umbrellaLight = analogRead(UMBRELLA_PIN);

  // check for buttons being pressed (without repeats)
  if(currCamera == LOW and lastCamera == HIGH ) {
    Serial.println("Photo taken");
  }
  if(currPot == LOW and lastPot == HIGH) {
    Serial.println("Pot bangeed");
  }
  // for the umbrella we check if the light crossed the threshold
  // and if the last state of the umbrella was unopened/false
  if(umbrellaLight > umbrellaThreshold and lastUmbrella == false) {
    currUmbrella = true;  // it's open now, so set state to true
    Serial.println("Umbrella opened");
  }
  if(umbrellaLight < umbrellaThreshold) {
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
