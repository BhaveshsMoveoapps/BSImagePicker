
# react-native-bs-image-picker

## Getting started

`$ npm install react-native-bs-image-picker --save`

### Mostly automatic installation

`$ react-native link react-native-bs-image-picker`

### Manual installation


#### iOS

1. In XCode, in the project navigator, right click `Libraries` ➜ `Add Files to [your project's name]`
2. Go to `node_modules` ➜ `react-native-bs-image-picker` and add `RNBsImagePicker.xcodeproj`
3. In XCode, in the project navigator, select your project. Add `libRNBsImagePicker.a` to your project's `Build Phases` ➜ `Link Binary With Libraries`
4. Run your project (`Cmd+R`)<

#### Android

1. Open up `android/app/src/main/java/[...]/MainActivity.java`
  - Add `import com.reactlibrary.RNBsImagePickerPackage;` to the imports at the top of the file
  - Add `new RNBsImagePickerPackage()` to the list returned by the `getPackages()` method
2. Append the following lines to `android/settings.gradle`:
  	```
  	include ':react-native-bs-image-picker'
  	project(':react-native-bs-image-picker').projectDir = new File(rootProject.projectDir, 	'../node_modules/react-native-bs-image-picker/android')
  	```
3. Insert the following lines inside the dependencies block in `android/app/build.gradle`:
  	```
      compile project(':react-native-bs-image-picker')
  	```

#### Windows
[Read it! :D](https://github.com/ReactWindows/react-native)

1. In Visual Studio add the `RNBsImagePicker.sln` in `node_modules/react-native-bs-image-picker/windows/RNBsImagePicker.sln` folder to their solution, reference from their app.
2. Open up your `MainPage.cs` app
  - Add `using Bs.Image.Picker.RNBsImagePicker;` to the usings at the top of the file
  - Add `new RNBsImagePickerPackage()` to the `List<IReactPackage>` returned by the `Packages` method


## Usage
```javascript
import RNBsImagePicker from 'react-native-bs-image-picker';

// TODO: What to do with the module?
RNBsImagePicker;
```
  