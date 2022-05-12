<template>
  <CThemeProvider>
    <div class="login-page">
      <div class="content">
        <div>
          <img src="~/assets/images/logo/ewadul-sby-group.png" alt="E Wadul" style="height: 200px;" />
        </div>
        <div class="card">
          <!-- <fa :icon="['fab', 'linkedin']"/> -->
          <!-- <div @click="showHidePass()">
          <i class="fa fa-eye" />
        </div> -->
          <div class="mb-5">
            <ValidationProvider name="Email/Username" rules="required" v-slot="{ errors }">
              <label class="text-body2">Email/Username</label>
              <c-input placeholder="Email/Username" class="mt-1 input-primary" v-model="username" />
              <span class="text-error">{{ errors[0] }}</span>
            </ValidationProvider>
          </div>
          <div class="mb-5">
            <ValidationProvider name="Password" rules="required" v-slot="{ errors }">
              <label class="text-body2" @click="showHidePass()">Password</label>
              <c-input-group size="md">
                <c-input pr="4.5rem" :type="show ? 'text' : 'password'" placeholder="Password" class="input-primary mt-1" v-model="password" @click="showHidePass()" />
                <c-input-right-element width="4.5rem">
                  <font-awesome-icon class="cursor-pointer" :icon="['fas', 'eye']" @click="showHidePass()" v-if="show" />
                  <font-awesome-icon class="cursor-pointer" :icon="['fas', 'eye-slash']" @click="showHidePass()" v-else />
                </c-input-right-element>
              </c-input-group>
              <span class="text-error">{{ errors[0] }}</span>
            </ValidationProvider>
          </div>
          <div>
            <div class="w-full flex justify-center">
              <c-button variant-color="green" class="btn-green-3 rounded-full">Button</c-button>
            </div>
            <div class="mt-10">
              <p class="text-center text-sm">Don't have an account? <b class="cursor-pointer">Sign Up</b></p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </CThemeProvider>
</template>

<script>
import {
  CInput,
  CButton,
  CInputRightElement,
  CInputGroup
} from '@chakra-ui/vue'
import {
  ValidationProvider
} from 'vee-validate'

export default {
  name: 'LoginIndex',
  components: {
    CInput,
    ValidationProvider,
    CButton,
    CInputRightElement,
    CInputGroup
  },
  data() {
    return {
      username: null,
      password: 'kurama<3naruto',
      show: false

    }
  },
  methods: {
    showHidePass() {
      console.log('masuk', this.show)
      this.show = !this.show
    }
  }
}
</script>

<style src="~/assets/styles/scss/layout/login.scss" lang="scss"></style>
