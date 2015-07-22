import processing.serial.*;

Serial myPort;  // Create object from Serial class
int val;      // Data received from the serial port

void setup() {
  size(500, 500, OPENGL);

  String portName = Serial.list()[7];
  println(Serial.list());
  myPort = new Serial(this, portName, 9600);
}

void draw() {
  float x = 0;
  float y = 0;
  float z = 0;
  
  if (myPort.available () > 2) {
    x = map(myPort.read(),0,1024,0,TWO_PI);
    y = map(myPort.read(),0,1024,0,TWO_PI);
    z = map(myPort.read(),0,1024,0,TWO_PI);

  
  }

  background(0);
  pushMatrix();
  translate(width/2, height/2, 0);
  rotateX(x);
  rotateY(y);
  rotateZ(z);
  box(100);
  popMatrix();
}

