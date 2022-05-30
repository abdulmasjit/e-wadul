<template>
  <div id="admin-left-panel" class="container-left-panel">
    <!-- <c-drawer
   :placement="placement"
   :isOpen="isOpen"
   class="left-panel">
      <c-drawer-overlay />
      <c-drawer-content>
        <div class="body-left-panel">
          <LeftPanelContent />
        </div>
      </c-drawer-content>
    </c-drawer> -->
    <div class="left-panel lg:block md:hidden hidden">
      aaaaaaaaaaa
      <div class="body-left-panel">
        <LeftPanelContent />
      </div>
    </div>
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
