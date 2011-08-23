DLL := omarkhd.DataStructures.dll

test_arraylist.exe: $(DLL) test_arraylist.cs
	gmcs test_arraylist.cs -r:$(DLL)

$(DLL): ../omarkhd.DataStructures.dll
	ln -s ../omarkhd.DataStructures.dll ./
