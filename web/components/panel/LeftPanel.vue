<template>
  <div id="admin-left-panel" class="container-left-panel">
    <c-drawer :placement="placement" :isOpen="isOpen" class="left-panel">
      <c-drawer-overlay />
      <c-drawer-content>
        <!-- <c-drawer-header borderBottomWidth="1px" class="header-left-panel">Basic Drawer</c-drawer-header> -->
        <div class="body-left-panel">
          <!-- <div class=" bg-red-300 mt-28">aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa</div> -->
          <LeftPanelContent />
          <!-- <p>Some contents...</p>
          <p>Some contents...</p>
          <p>Some contents...</p> -->
        </div>
      </c-drawer-content>
    </c-drawer>
  </div>
</template>

<script>
import {
  CDrawer,
  CDrawerBody,
  CDrawerFooter,
  CDrawerHeader,
  CDrawerOverlay,
  CDrawerContent,
  CDrawerCloseButton,
} from '@chakra-ui/vue'
import LeftPanelContent from '~/components/panel/LeftPanelContent.vue'

export default {
  name: 'LeftPanel',
  components: {
    CDrawer,
    CDrawerHeader,
    CDrawerBody,
    CDrawerFooter,
    CDrawerOverlay,
    CDrawerContent,
    CDrawerCloseButton,
    LeftPanelContent
  },
  data() {
    return {
      isOpen: true,
      placement: 'left'
    }
  }
}
</script>

<style>

</style>
