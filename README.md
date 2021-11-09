# Dual-Joystick-Text-Input

## Übersicht
<img width="500" alt="kreiseFinal" src="https://user-images.githubusercontent.com/54246844/140310287-8c08a8bf-cc80-4bdb-8d30-2cb009a9589c.PNG">  
Dieses Projekt dient der Entwicklung und Evaluation eines Dual-Joystick Texteingabesystems für den XboxOne Controller.
Das entwickelte System kodiert auf jedem Joystick je acht Zeichen, und ist im Vergleich zu einem Selection Keyboard schnell mit einer höheren Geschwindigkeit zu adaptieren.  

## Systemfunktion
<img width="1200" alt="winklerSmall" src="https://user-images.githubusercontent.com/54246844/140308869-3f41a444-950b-407e-ab0c-39300f9c2850.png">  
Zur Eingabe eines Zeichens, muss der entsprechende Joystick in den Eingabebereich geführt werden. Die Eingabe erfolgt erst nach der Rückführung des Joysticks in die Neutalposition. Durch gedrückthalten der L1-Taste können die Eingabeschichten vertauscht werden.  

## Entwicklungsschritte  
### 1. Evaluation der Eingabegenauigkeit der Joystickzonen: 
<img width="500" alt="winkelzonen" src="https://user-images.githubusercontent.com/54246844/140296197-9265bb9f-440d-4f09-bbab-8fa08cb3cdac.PNG">  

### 2. Auswahl aus zwei Eingabesystemen:  
Ansatz über Codierung von je einem Zeichen über die relative Winkelstellung beider Joysticks zueinander (ähnl. [*Winkleralphabet*](https://de.wikipedia.org/wiki/Winkeralphabet)):  
<img width="500" alt="winklerSmall" src="https://user-images.githubusercontent.com/54246844/140297123-edacd143-4cdc-44b1-87af-b8de6e2b0128.png">   
### VS.
Ansatz über die Codierung von einem Zeichen auf jeder möglichen Position der Analogsticks:  
<img width="500" alt="kreiseSmall" src="https://user-images.githubusercontent.com/54246844/140298606-8c527dcc-1744-4501-90ce-7c95c460d0d0.png">
### 3. Bestimmung eines Geeigneten Layouts:
Anordnung der Buchstaben in Alphabetischer Reihenfolge:  
<img width="500" alt="11" src="https://user-images.githubusercontent.com/54246844/140301051-3a62aac9-59b9-4658-b632-e5e88adb5328.png">  
Anordnung der Buchstaben anhand des QWERTY Layouts:  
<img width="500" alt="12" src="https://user-images.githubusercontent.com/54246844/140301280-96bdd140-ec23-4f79-a2db-2a26e189482a.png">  
Anordnung der Buchstaben anhand ihrer Häufigkeit in der englischen Literatur:  
<img width="500" alt="13" src="https://user-images.githubusercontent.com/54246844/140301396-421cd86a-526f-4b08-b9a6-9ec96650ab37.png">  
## Ergebnisse
In einer mehrtägigen Studie mussten Probanden jeden Tag Testeingaben mit dem Kreissystem und einem Selection Keyboard tätigen. Anhand der Eingaben wird die Systemperformance dargestellt.  
Eingabegeschwindigkeit:  
<img width="500" alt="cWpm" src="https://user-images.githubusercontent.com/54246844/140941631-fbd99658-458c-4357-a02c-783e46bd2341.png">  
Keystrokes Per Character:  
<img width="500" alt="kspc" src="https://user-images.githubusercontent.com/54246844/140941945-7dc3698c-4e90-4c72-89d8-d98a1a3d7dd2.png">    
NASA Taskload:  
<img width="500" alt="nasa" src="https://user-images.githubusercontent.com/54246844/140942693-cd7ab05c-c9c9-413a-b514-fc54440fbdb5.png">   
Fehlerrate:  
<img width="500" alt="err" src="https://user-images.githubusercontent.com/54246844/140942838-2022de33-2e04-4cf5-bb8f-765d9b826879.png">   
