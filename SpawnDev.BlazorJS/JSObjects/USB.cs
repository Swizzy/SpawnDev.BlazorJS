﻿using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The USB interface of the WebUSB API provides attributes and methods for finding and connecting USB devices from a web page.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/USB
    /// </summary>
    public class USB : EventTarget
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public USB(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region 
        /// <summary>
        /// Returns a Promise that resolves with an array of USBDevice objects for paired attached devices.
        /// </summary>
        /// <returns></returns>
        public Task<Array<USBDevice>> GetDevices() => JSRef!.CallAsync<Array<USBDevice>>("getDevices");
        /// <summary>
        /// Returns a Promise that resolves with an instance of USBDevice if the specified device is found. Calling this function triggers the user agent's pairing flow.
        /// </summary>
        /// <returns></returns>
        public Task<USBDevice> RequestDevice(USBDeviceRequestOptions options) => JSRef!.CallAsync<USBDevice>("requestDevice", options);
        #endregion

        #region Events
        /// <summary>
        /// The connect event of the USB interface is fired whenever a paired device is connected.
        /// </summary>
        public ActionEvent<USBConnectionEvent> OnConnect { get => new ActionEvent<USBConnectionEvent>("connect", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// The disconnect event of the USB interface is fired whenever a paired device is disconnected.
        /// </summary>
        public ActionEvent<USBConnectionEvent> OnDisconnect { get => new ActionEvent<USBConnectionEvent>("disconnect", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}
