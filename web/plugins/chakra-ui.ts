import Vue from 'vue'
import customTheme from '~/custom-theme'
// import 'animate.css'
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
  CModalCloseButton,
  CTextarea,
  CBreadcrumb,
  CBreadcrumbItem,
  CBreadcrumbLink,
  CBreadcrumbSeparator,
  CMenu,
  CMenuButton,
  CMenuList,
  CMenuItem,
  CMenuGroup,
  CMenuDivider,
  CMenuOptionGroup,
  CMenuItemOption,
  CPopover,
  CPopoverTrigger,
  CPopoverContent,
  CPopoverHeader,
  CPopoverBody,
  CPopoverFooter,
  CPopoverArrow,
  CPopoverCloseButton
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
  CModalCloseButton,
  CTextarea,
  CBreadcrumb,
  CBreadcrumbItem,
  CBreadcrumbLink,
  CBreadcrumbSeparator,
  CMenu,
  CMenuButton,
  CMenuList,
  CMenuItem,
  CMenuGroup,
  CMenuDivider,
  CMenuOptionGroup,
  CMenuItemOption,
  CPopover,
  CPopoverTrigger,
  CPopoverContent,
  CPopoverHeader,
  CPopoverBody,
  CPopoverFooter,
  CPopoverArrow,
  CPopoverCloseButton
}

Object.entries(components).forEach(([name, component]) => {
  Vue.component(name, component)
})