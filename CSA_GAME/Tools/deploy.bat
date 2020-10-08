C:\Windows\System32\OpenSSH\scp.exe -r $(TargetDir) pi@raspberrypi:/home/pi/apps/$(ProjectName)

$(SolutionDir)SecureUpload.exe $(TargetDir) pi-home:pi/apps/$(ProjectName)
#scp -r $(TargetDir) pi@raspberrypi:/home/pi/apps/$(ProjectName)