#define button_B	3 // red
#define button_C	4 // blue
#define button_A	5 // joystick_in
//#define joystick_X      A0
//#define joystick_Y      A1
#define buzzer_VDD      A2
#define buzzer_ANL      A3
#define ledPin          13 //a testing/status LED

byte inputByte0; // start of message (always 16)
byte inputByte1; // message type: 126 for get data, 127 for send data, 128 for ID
byte inputByte2; // data name (0 for Start, 1 for Stop, 
                 // 100 for Button_A, 101 for button_B, 102 for button_C, 103 for X, 104 for Y,
                 // 200 for testCountMax, 201 for timeMin, 202 for timeMax)
byte inputByte3; // data value, only used to set testCountMax, timeMin, and timeMax
byte inputByte4; // end of message (always 4)

boolean toggleLED = false;
boolean identified = false;
boolean Stop = false;
boolean Start = false;
boolean lastButton = HIGH;
boolean currentButton = HIGH;
boolean buttonPressed = false;
boolean earlyCheck = false;
boolean startedTimer = false;

long startTime;
long endTime;
long randomTime;
float elapsedTime;

int timeMin = 2; // minimum wait time in seconds
int timeMax = 5;
int testCount = 1;
int testCountMax = 1;

void setup () {
	Serial.begin (9600);
	pinMode (button_B, INPUT);
	pinMode (button_C, INPUT);
	pinMode (button_A, INPUT);
        attachInterrupt(1, red_button, FALLING); // ISR1 (pin 3) for when button is pressed (LOW)
        pinMode (ledPin, OUTPUT);
        pinMode (buzzer_VDD, OUTPUT);
        pinMode (buzzer_ANL, OUTPUT);
}

void loop () {
  digitalWrite(buzzer_VDD, HIGH);
  if(identified && !Stop){
        currentButton = debounce(lastButton, button_B);
        if(lastButton == LOW && currentButton == HIGH){
          buttonPressed = true;
          lastButton = HIGH;
        }
        lastButton = currentButton;
        
        if(buttonPressed == true && startedTimer == false){
          //Start  = true;
          //Serial.print("\nARDUINO_STARTING \n");
          buttonPressed = false;
        }
        
        if(Start == true && startedTimer == false){
          startedTimer  = true;
          randomWait();
        }
        
        if(startedTimer == true && (millis()-startTime >= 1000 )){
          //turn off buzzer after 1 second
          digitalWrite(buzzer_ANL, LOW);
        }
        
        if(buttonPressed == true && startedTimer == true){
          sendResult();
          startedTimer = false;
          buttonPressed = false;
          if (testCount >= testCountMax){
            Start = false;
            testCount = 1;
            Serial.print(" \nARDUINO_DONE \n");
            delay(100);
            Serial.print("\nARDUINO_READY \n");
          } else 
            testCount++;
        }      
  }
  if (Stop){
    testCount = 1;
    Start = false;
    Stop = false;
    startedTimer = false;
    buttonPressed = false;
    Serial.print(" \nARDUINO_DONE \n");
    digitalWrite(ledPin, LOW);
    Serial.print("\nARDUINO_READY \n");
  }
  
  SerialRead();
}


void red_button(){
  //ISR for when red button is pressed
  if(earlyCheck){
    earlyCheck = false;
    Serial.print("\nARDUINO_EARLY \n");
  }
  //Serial.print("ARDUINO_BUTTON ");
}
boolean debounce(boolean last, int switchPin){
  boolean current = digitalRead(switchPin);
  if(last != current)
  {
    delay(5);
    current = digitalRead(switchPin);
  }
  return current;
}
void randomWait(){
  randomTime = random(timeMin,timeMax)*1000;
  digitalWrite(ledPin, HIGH);
  delay(100);
  digitalWrite(ledPin, LOW);
  earlyCheck = true;
  delay(randomTime);
  earlyCheck = false;
  startTime = millis();
  digitalWrite(ledPin, HIGH);
  digitalWrite(buzzer_ANL, HIGH);
}
void sendResult(){
  endTime = millis();
  elapsedTime = (endTime - startTime)+5;
  elapsedTime = elapsedTime/1000.0;
  Serial.print("\nARDUINO_TIME \n");
  char buffer[10];
  Serial.println(dtostrf(elapsedTime,10,8,buffer));
  Serial.print("END \n");
  digitalWrite(ledPin, LOW);
  digitalWrite(buzzer_ANL, LOW);
}

void SerialRead(){
        if (Serial.available() == 5) {
          //Read buffer
          inputByte0 = Serial.read();
          delay(100);    
          inputByte1 = Serial.read();
          delay(100);      
          inputByte2 = Serial.read();
          delay(100);      
          inputByte3 = Serial.read();
          delay(100);
          inputByte4 = Serial.read();
          if(inputByte0 == 16 && inputByte4 == 4){
            switch (inputByte1){
              case 128:
                // Program is asking for identification
                Serial.print("\nARDUINO_IDENTIFY \n");
                identified = true;
                break;
              case 127:
                //Program is sending data
                if(inputByte2 == 0){
                  Start = true;
                  Stop = false;
                  Serial.print("\nARDUINO_STARTING \n");
                }else if(inputByte2 == 1){
                  Stop = true;
                  Start = false;
                  Serial.print("\nARDUINO_STOPPING \n");
                }else if(inputByte2 == 200){
                  testCountMax = inputByte3;
                }else if(inputByte2 == 201){
                  timeMin = inputByte3;
                }else if(inputByte2 == 202){
                  timeMax = inputByte3;
                }
                //not implemented: get values for inputByte 100 to 104
                break;
              case 126:
                //Program wants data
                break;
            }
            inputByte0 = 0;
            inputByte1 = 0;
            inputByte2 = 0;
            inputByte3 = 0;
            inputByte4 = 0;
            Serial.print("\nARDUINO_READY \n");
          }
        }
}

void idleLED(){
        digitalWrite (ledPin, toggleLED);
        toggleLED = !toggleLED;
        delay (500);
}
/*
void testInputs(){
        int state_A = digitalRead (button_A);
	int state_B = digitalRead (button_B);
	int state_C = digitalRead (button_C);
        int state_X = analogRead (joystick_X);
        int state_Y = analogRead (joystick_Y);
        Serial.print("state_A = ");
	Serial.print (state_A);
        Serial.print("\nstate_B = ");
	Serial.print (state_B);
        Serial.print("\nstate_C = ");
	Serial.print (state_C);
        Serial.print("\nstate_X = ");
	Serial.print (state_X);
        Serial.print("\nstate_Y = ");
	Serial.print (state_Y);
	Serial.print("\n");
}
*/
