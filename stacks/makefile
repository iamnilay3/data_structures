DLL := omarkhd.DataStructures.dll

test.exe: $(DLL) test.cs
	gmcs test.cs -r:$(DLL)

$(DLL): ../omarkhd.DataStructures.dll
	ln -s ../omarkhd.DataStructures.dll ./
