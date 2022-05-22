import Vue from 'vue'
import customTheme from '~/custom-theme'
import Chakra, {
  CThemeProvider,
  CInput,
  CButton,
  CInputRightElement,
  CInputGroup,
  CAvatar,
  CAvatarBadge,
  CTooltip,
  CIcon,
  CModal,
  CModalOverlay,
  CModalContent,
  CModalHeader,
  CModalFooter,
  CModalBody,
  CModalCloseButton
} from '@chakra-ui/vue'
import { faTrash, faPen } from '@fortawesome/free-solid-svg-icons'

Vue.use(Chakra, {
  extendTheme: customTheme,
  icons: {
    iconPack: 'fa',
    iconSet: {
      faPen,
      faTrash
    }
  }
})
const components = {
  CThemeProvider,
  CButton,
  CInput,
  CInputRightElement,
  CInputGroup,
  CAvatar,
  CAvatarBadge,
  CTooltip,
  CIcon,
  CModal,
  CModalOverlay,
  CModalContent,
  CModalHeader,
  CModalFooter,
  CModalBody,
  CModalCloseButton
}

Object.entries(components).forEach(([name, component]) => {
  Vue.component(name, component)
})