/* Import all the font awesome goodness */
import Vue from 'vue'
import { library, dom, config } from '@fortawesome/fontawesome-svg-core'
import { faTwitter } from '@fortawesome/free-brands-svg-icons'
import { faUserSecret, fas, faCoffee, faMusic } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
config.autoAddCss = false

library.add(faUserSecret, faTwitter, fas, faCoffee, faMusic)
dom.watch();

Vue.component('font-awesome-icon', FontAwesomeIcon)