using ReactNative.Bridge;
using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Media.Capture;
using Windows.Foundation;

namespace Bs.Image.Picker.RNBsImagePicker
{
   
    /// <summary>
    /// A module that allows JS to share data.
    /// </summary>
    class RNBsImagePickerModule : NativeModuleBase
    {
        CameraCaptureUI captureUI = new CameraCaptureUI();
        private StorageFile storeFile;
        private IRandomAccessStream stream;
        /// <summary>
        /// Instantiates the <see cref="RNBsImagePickerModule"/>.
        /// </summary>
        internal RNBsImagePickerModule()
        {
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);
            
            //Define 
        }

        /// <summary>
        /// The name of the native module.
        /// </summary>
        public override string Name
        {
            get
            {
                return "RNBsImagePicker";
            }
        }

        /// <summary>
        /// Open Share UI and provide data for sharing.
        /// </summary>
        [ReactMethod]
        public void showPhotos(ICallback errorCallback, ICallback successCallback)
        {

           RunOnDispatcher(async() => {
               try
               {
                 FileOpenPicker openPicker = new FileOpenPicker();
                 openPicker.ViewMode = PickerViewMode.Thumbnail;
                 openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                 openPicker.FileTypeFilter.Add(".jpg");
                 openPicker.FileTypeFilter.Add(".jpeg");
                 openPicker.FileTypeFilter.Add(".png");

                 StorageFile file = await openPicker.PickSingleFileAsync();


                 if(file != null)
                 {
                  byte[] fileBytes = null;
                    using (var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                    {
                        fileBytes = new byte[stream.Size];
                        using (var reader = new DataReader(stream))
                        {
                            await reader.LoadAsync((uint)stream.Size);
                            reader.ReadBytes(fileBytes);
                        }
                    }
   
                   successCallback.Invoke(fileBytes);
                 }
                 else
                 {
                   errorCallback.Invoke("not_available image");
                 }

               }
               catch
               {
                   errorCallback.Invoke("not_available");
               }
           });
        }

        [ReactMethod]
        public async void captureImage(ICallback errorCallback, ICallback successCallback)
        {

            RunOnDispatcher(async () => {
                try
                {
                    CameraCaptureUI capture = new CameraCaptureUI();
                    capture.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
                    capture.PhotoSettings.CroppedAspectRatio = new Size(3, 5);
                    capture.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable;
                    storeFile = await capture.CaptureFileAsync(CameraCaptureUIMode.Photo);

                    if (storeFile != null)
                    {
     
                      byte[] fileBytes = null;
                      using (var stream = await storeFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
                      {
                          fileBytes = new byte[stream.Size];
                          using (var reader = new DataReader(stream))
                          {
                              await reader.LoadAsync((uint)stream.Size);
                              reader.ReadBytes(fileBytes);
                          }
                      }
                           
                      successCallback.Invoke(fileBytes);
                    }
                    else
                    {
                        errorCallback.Invoke("image not_available");

                    }
                }
                catch (Exception error)
                {
                    errorCallback.Invoke(error);

                }
            });

        }

        private static async void RunOnDispatcher(DispatchedHandler action)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, action);
        }
    }
}
