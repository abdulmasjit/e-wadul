import Vue from 'vue';
import { ValidationProvider, extend } from 'vee-validate';
import {
  required,
  email
} from 'vee-validate/dist/rules';


extend('required', {
  ...required,
  message: '{_field_} harus diisi'
});
// Add a rule.
// extend('secret', {
//   validate: value => value === 'example',
//   message: 'This is not the magic word'
// });

// Register it globally
Vue.component('ValidationProvider', ValidationProvider);