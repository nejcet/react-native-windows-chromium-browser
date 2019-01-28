import PropTypes from 'prop-types';
import { requireNativeComponent, ViewPropTypes, NativeModules } from 'react-native';

var iface = {
  name: 'ChromiumWebView',
  propTypes: {
    source: PropTypes.any,
    ...ViewPropTypes // include the default view properties
  },
};

const ChromiumOptions = NativeModules.ChromiumOptions

const AddLicense = (licenceKey) => {
  return ChromiumOptions.AddLicense(licenceKey)
}

module.exports = {
  WebView: requireNativeComponent('ChromiumWebView', iface),
  AddLicense: AddLicense
}
