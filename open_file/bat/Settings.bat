adb root
adb remount
adb push Z:\2021-7-19\sdm450_a7\sdm450_a7\out\target\product\msm8953_64\system\priv-app\Settings\Settings.apk system/priv-app/Settings
adb push Z:\2021-7-19\sdm450_a7\sdm450_a7\out\target\product\msm8953_64\system\priv-app\Settings\oat\arm64\Settings.odex system/priv-app/Settings/oat/arm64
adb reboot
TIMEOUT /T 15 /NOBREAK
exit