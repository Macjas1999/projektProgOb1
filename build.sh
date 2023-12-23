#! /bin/bash
mcs MapTemplate.cs ParkingPlace.cs MainControl.cs MapCreator.cs -out:main.exe main.cs
mono main.exe
