cp "ODFXMaker/bin/Debug/ODFXMaker.exe" "DarkFlow/bin/Debug/ODFXMaker.exe"
cp "HTML5/bin/Debug/HTML5.exe" "DarkFlow/bin/Debug/PlatformProfiles/HTML5.exe"
cp "PCRunner/bin/Debug/PCRunner.exe" "DarkFlow/bin/Debug/PlatformProfiles/Windows.exe"

rm -rf release
cp -R DarkFlow/bin/Debug release
cd release
rm -rf DFTemp
rm -rf LoadProject
rm Options.dat
rm DarkFlow.xml
rm *.vshost.exe*
rm *.exe.config*
rm *.pdb
rm .gitignore
rm .DS_Store
rm Thumbs.db
cd ..