const int player1 = A0;
const int player2 = A1;

const int btnStart = 8;

const int player1LedRed = 5;
const int player1LedGreen = 6;

const int player2LedGreen = 11;
const int player2LedRed = 12;

void setup()
{
    Serial.begin(9600); // Serieller Monitor Starten 

    pinMode(btnStart, INPUT);

    pinMode(player1LedGreen, OUTPUT);
    pinMode(player1LedRed, OUTPUT);
    pinMode(player2LedGreen, OUTPUT);
    pinMode(player2LedRed, OUTPUT);
}

void loop()
{
    delay(30);
    Serial.print(map(analogRead(player1), 0, 1023, 0, 100));
    Serial.print(",");
    Serial.print(map(analogRead(player2), 0, 1023, 0, 100));
    Serial.print(",");
    Serial.println(digitalRead(btnStart));

	if(Serial.available() > 0){
	
		byte data = (int) Serial.read();

		switch(data){
			case 0:
				digitalWrite(player1LedGreen, LOW);
				digitalWrite(player1LedRed, LOW); 
				digitalWrite(player2LedGreen, LOW);
				digitalWrite(player2LedRed, LOW);
				break;
			case 1:        
				setLeds(true, false);
				break;
			case 2:           
				setLeds(false, true);
				break;
			case 3: 
				setLeds(true, true);
				break;
			case 4: 
				setLeds(false, false);
				break;
		} 
	}
}

void setLeds(bool player1, bool player2){
    if(player1){      
        digitalWrite(player1LedRed, LOW);
        digitalWrite(player1LedGreen, HIGH); 
    }else{
        digitalWrite(player1LedGreen, LOW); 
        digitalWrite(player1LedRed, HIGH); 
    }
    if(player2){
        digitalWrite(player2LedRed, LOW); 
        digitalWrite(player2LedGreen, HIGH);
    }else{
        digitalWrite(player2LedGreen, LOW);
        digitalWrite(player2LedRed, HIGH);       
    }
}




