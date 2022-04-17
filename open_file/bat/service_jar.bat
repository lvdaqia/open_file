adb root
adb remount
adb push Z:\2021-7-19\sdm450_a7\sdm450_a7\out\target\product\msm8953_64\system\framework\services.jar system/framework/
adb reboot
TIMEOUT /T 15 /NOBREAK
exit