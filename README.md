
# BSImagePicker

## Getting started

`$ npm install bsimagepicker --save`

### Mostly automatic installation

`$ react-native link bsimagepicker`

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
             RNBImagePicker.openPhotos()
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
           setTimeout(() => {
             RNBImagePicker.takePhoto()
             .then((response) => {
               console.log(response);
               this.setState({
                 imgSource:response
               })
             })
           },300);
         }}>Take Photo</Button>
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
