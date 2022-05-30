import Vue from 'vue';
import { ValidationProvider, extend, ValidationObserver } from 'vee-validate';
import {
  required,
  email,
  min
} from 'vee-validate/dist/rules';


extend('required', {
  ...required,
  message: '{_field_} harus diisi'
});

extend('email', {
  ...email,
  message: '{_field_} tidak valid'
});

extend('min', {
  ...min,
  params: ['length'],
  message: '{_field_} minimal mengandung {length} karakter'
});

// Register it globally
Vue.component('ValidationProvider', ValidationProvider);
Vue.component('ValidationObserver', ValidationObserver)