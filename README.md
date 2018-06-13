# 2018_LaserBarrier

## Overview

Our goal was to create a pair of laser gates used for measuring time it takes an object to get from start (first gate) to finish (second gate). The results are then sent to the desktop application of our design and displayed.

## Description 

Each gate consists of a laser diode pointed at photoresistor connected to the microcontroller and a Bluetooth module. When the program is run on the microcontroller, it first finds out what the average light level at the photoresistor is and, based on that data, sets a threshold. When light level drops below that threshold (that is when an object crosses the laser beam) microcontroller sends a signal to the application via Bluetooth. The application uses events to read current time at the moment of message arrivel at COM port. After receiving message from the microcontroller marked as the starting point, the application waits for a message from the end gate. When the message from the second microcontroller arrives (both gates work exactly the same), the time between those two alerts is calculated and displayed. 


//When the object reaches the finish gate, the same thing happens and the application calculates the time elapsed between the two signals.

## Tools

* System Workbench for STM32\
* Arduino or Hercules Setup Utility by HW-Group.com\
* Visual Studio\
* Microcontroller STM32F407VG DISCOVERY\
* Bluetooth HC-06 ZS-040 module\
* Red laser diode 5mW 5V\
* Photoresistor 5-10kΩ GL5616\

## How to run

### Wires connection
#### Bluetooth module
GND -> GND\
VCC -> 3V\
RX -> PC10\
TX -> PC11

#### Photoresistor with resistor
GND -> GND\
VCC -> VCC\
IN -> PA1

### Steps

Connect all pins according to the instructions above.\
Download the code, build and run it on System WorkBench for STM32 (v. 2.2.0) or any other compatible STM32 compiler.

## How to compile

There is no need to change anything in the source code, it's ready for compilation.

## Future improvements

## Attributions

## License
[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

- **[MIT license](http://opensource.org/licenses/mit-license.php)**

## Credits
Jakub Smierzchalski\
Michał Ściborski [msciborski](https://github.com/msciborski)\
Kamila Urbaniak - [camilqa](https://github.com/camilqa)

The project was conducted during the Microprocessor Lab course held by the Institute of Control and Information Engineering, Poznan University of Technology.\
Supervisor: Adam Bondyra
