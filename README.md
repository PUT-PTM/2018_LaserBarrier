# 2018_LaserBarrier

## Overview

Our goal was to create a console application and a pair of laser gates used for measuring time it takes an an object to get from start (first gate) to finish (second gate). Each gate consists of a Bluetooth module and a laser diode pointed at photoresistor attached to the microcontroller. When the object passes the laser beam of the first gate, the first microcontroller sends an information to the application via Bluetooth. When the object reaches the finish gate, the same thing happens and the application calculates the time elapsed between the two signals.

## Description 

## Tools

* System Workbench for STM32 do ...
* Arduino or Hercules Setup Utility by HW-Group.com do ...
* Visual Studio to ...
* Microcontroller STM32F407VG DISCOVERY do ...
* Bluetooth HC-06 ZS-040 module do ...
* Red laser diode 5mW 5V do ...
* Photoresistor 5-10kΩ GL5616 do ...

## How to run

### Wire connections
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

Download the code, build and run it on System WorkBench for STM32 (v. 2.2.0) or other compatible STM32 compiler.\
Connect all pins with schema.

## How to compile

There is no need to change anything in source code, compile as is.

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
