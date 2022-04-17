adb root
adb remount
adb push \\192.168.1.33\lvdaqian\2021-7-19\sdm450_a7\sdm450_a7\out\target\product\msm8953_64\system\priv-app\HyteraUserManager\HyteraUserManager.apk system/priv-app/HyteraUserManager
adb push \\192.168.1.33\lvdaqian\2021-7-19\sdm450_a7\sdm450_a7\out\target\product\msm8953_64\system\priv-app\HyteraUserManager\oat\arm64\HyteraUserManager.odex system/priv-app/HyteraUserManager/oat/arm6
adb push \\192.168.1.33\lvdaqian\2021-7-19\sdm450_a7\sdm450_a7\out\target\product\msm8953_64\system\lib64\libHyteraUserManager.so system/lib64/
adb reboot
pause