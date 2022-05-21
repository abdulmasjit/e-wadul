import Vue from 'vue'
import customTheme from '~/custom-theme'
import Chakra, {
  CThemeProvider,
  CInput,
  CButton,
  CInputRightElement,
  CInputGroup
} from '@chakra-ui/vue'

Vue.use(Chakra, {
  extendTheme: customTheme
})
const components = {
  CThemeProvider,
  CButton,
  CInput,
  CInputRightElement,
  CInputGroup
}

Object.entries(components).forEach(([name, component]) => {
  Vue.component(name, component)
})