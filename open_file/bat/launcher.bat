adb root
adb remount
adb push Z:\2021-7-23\sdm450_a7\sdm450_a7\out\target\product\msm8953_64\system\app\Launcher\Launcher.apk system/app/Launcher
adb push Z:\2021-7-23\sdm450_a7\sdm450_a7\out\target\product\msm8953_64\system\app\Launcher\oat\arm64\Launcher.odex system/app/Launcher/oat/arm64
adb reboot
pause