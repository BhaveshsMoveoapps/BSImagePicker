
# BSImagePicker

## Getting started

`$ npm install bsimagepicker --save`

### Mostly automatic installation

`$ react-native link bsimagepicker`

### Manual installation


#### iOS

1. In XCode, in the project navigator, right click `Libraries` ➜ `Add Files to [your project's name]`
2. Go to `node_modules` ➜ `bsimagepicker` and add `RNBsImagePicker.xcodeproj`
3. In XCode, in the project navigator, select your project. Add `libRNBsImagePicker.a` to your project's `Build Phases` ➜ `Link Binary With Libraries`
4. Run your project (`Cmd+R`)<

#### Android

1. Open up `android/app/src/main/java/[...]/MainActivity.java`
  - Add `import com.reactlibrary.RNBsImagePickerPackage;` to the imports at the top of the file
  - Add `new RNBsImagePickerPackage()` to the list returned by the `getPackages()` method
2. Append the following lines to `android/settings.gradle`:
  	```
  	include ':bsimagepicker'
  	project(':bsimagepicker').projectDir = new File(rootProject.projectDir, 	'../node_modules/react-native-bs-image-picker/android')
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

## Your JS File

```javascript
import RNBImagePicker, {PickerSheet, Button} from 'bsimagepicker';

export default class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      visible: false,
      imgSource: null
    }
  }
  onCancel() {
    console.log("CANCEL")
    this.setState({visible:false});
  }
  onOpen() {
    console.log("OPEN")
    this.setState({visible:true});
  }
  
  render() {
   return (
    <View style={styles.container}>
      <TouchableOpacity onPress={this.onOpen.bind(this)}>
        <View style={styles.instructions}>
          <Text>Pick Image</Text>
        </View>
      </TouchableOpacity>
     <PickerSheet visible={this.state.visible} onCancel={this.onCancel.bind(this)}>
       <Button onPress={()=>{
           this.onCancel();
           setTimeout(() => {
             RNBImagePicker.open()
             .then((response) => {
               console.log(response);
               this.setState({
                 imgSource:response
               })
             })
           },300);
         }}>Choose From Photos</Button>
       <Button onPress={()=>{
           this.onCancel();
         }}>Cancel</Button>
     </PickerSheet>
   </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    position: 'absolute',
    width: '100%',
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#F5FCFF',
    bottom: 0
  },
  instructions: {
    flex: 1,
    marginTop: 20,
    marginBottom: 20,
  },
});

```
