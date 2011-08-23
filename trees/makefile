DLL := omarkhd.DataStructures.dll

test1.exe: $(DLL) test1.cs
	gmcs test1.cs -r:$(DLL)

$(DLL): ../omarkhd.DataStructures.dll
	ln -s ../omarkhd.DataStructures.dll ./
