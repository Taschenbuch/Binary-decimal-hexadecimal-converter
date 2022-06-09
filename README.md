# Binary-decimal-hexadecimal-converter

[Download .exe here](https://github.com/Taschenbuch/Binary-decimal-hexadecimal-converter/releases)
 
- Convert between multiple binary, decimal and hexadecimal values. 
- Add a comment to them to remember what the value means.
- Add rows with the "+" button 
- Delete rows with the "x" button. 
- Show exact bit positions for the binary value.


![4](https://user-images.githubusercontent.com/43114787/75397946-884b6e80-58f8-11ea-9e57-4be08ac999fb.gif)

- Shows a hint when you enter invalid characters.

![grafik](https://user-images.githubusercontent.com/43114787/74632776-703d5780-5160-11ea-8860-413213f44448.png)

- portable app. No installation required. Works by just starting the .exe
- uses .NET Core 3.1
- uses [Material Design In XAML Toolkit](https://github.com/ButchersBoy/MaterialDesignInXamlToolkit)


### Build it
if you do not want to use the exe but compile it yourself:
- clone repo
- open the solution in Visual Studio 2022 
- you can now simply build it with Build -> Build solution
- if you want to have a single file .exe-file instead, do the following steps
  - Tools -> command line -> developer command prompt  
  - copy this command into the command prompt and press enter:  
 ```cd BinHexDecConverter ```
    - because otherwise it tries to add the unit test project to the single file and will fail doing that.
  - copy this command into the command prompt and press enter:
    - for systems where .net6 is NOT installed (it will include .net6 into the .exe):  
 ```dotnet publish --runtime win-x64 -c Release --self-contained true -p:PublishSingleFile=true -p:IncludeAllContentForSelfExtract=true```
    - for systems where .net6 IS installed (smaller .exe size because .net6 is not included):  
     ```dotnet publish --runtime win-x64 -c Release --self-contained false -p:PublishSingleFile=true -p:IncludeAllContentForSelfExtract=true```
  - the .exe will be in ```BinHexDecConverter\BinHexDecConverter\bin\Release\net6.0-windows\win-x64\publish```
  - the command has to be used because the Build -> publish dialog in visual studio is not able to do that yet (version 16.10.2).