using ReactNative.Bridge;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace Bs.Image.Picker.RNBsImagePicker
{
    /// <summary>
    /// A module that allows JS to share data.
    /// </summary>
    class RNBsImagePickerModule : NativeModuleBase
    {
        /// <summary>
        /// Instantiates the <see cref="RNBsImagePickerModule"/>.
        /// </summary>
        internal RNBsImagePickerModule()
        {

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
    }
}
