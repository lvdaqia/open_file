adb root
adb remount
adb push Z:\2021-7-19\sdm450_a7\sdm450_a7\out\target\product\msm8953_64\system\priv-app\SystemUI\oat\arm64\SystemUI.odex system/priv-app/SystemUI/oat/arm64
adb push Z:\2021-7-19\sdm450_a7\sdm450_a7\out\target\product\msm8953_64\system\priv-app\SystemUI\SystemUI.apk system/priv-app/SystemUI/
adb reboot
TIMEOUT /T 15 /NOBREAK
exit