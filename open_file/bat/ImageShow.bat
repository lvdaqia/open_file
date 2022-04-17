adb root
adb remount	
adb push Z:\2021-7-19\sdm450_a7\sdm450_a7\out\target\product\msm8953_64\system\app\ImageShow\ImageShow.apk system/app/ImageShow
adb push Z:\2021-7-19\sdm450_a7\sdm450_a7\out\target\product\msm8953_64\system\app\ImageShow\oat\arm64\ImageShow.odex system/app/ImageShow/oat/arm64
adb reboot
pause