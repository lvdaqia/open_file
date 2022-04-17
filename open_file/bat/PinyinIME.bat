adb root
adb remount
adb push Z:\2021-7-19\sdm450_a7\sdm450_a7\out\target\product\msm8953_64\system\app\PinyinIME\PinyinIME.apk system/app/PinyinIME
adb push Z:\2021-7-19\sdm450_a7\sdm450_a7\out\target\product\msm8953_64\system\app\PinyinIME\oat\arm64\PinyinIME.odex  system/app/PinyinIME/oat/arm64
adb reboot
pause