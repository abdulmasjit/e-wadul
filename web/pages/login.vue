<template>
  <CThemeProvider>
    <div class="login-page">
      <div class="content">
        <div>
          <img src="~/assets/images/logo/ewadul-sby-group.png" alt="E Wadul" style="height: 200px;" />
        </div>
        <div class="card">
          <ValidationObserver ref="form">
            <form @submit.prevent="submit">
              <div class="mb-5">
                <ValidationProvider
                  name="Email/Username"
                  rules="required"
                  v-slot="{ errors }">
                  <label class="text-body2">Email/Username</label>
                  <c-input
                    placeholder="Email/Username"
                    class="mt-1"
                    focus-border-color="primary"
                    v-model="username" />
                  <span class="text-error">{{ errors[0] }}</span>
                </ValidationProvider>
              </div>
              <div class="mb-5">
                <ValidationProvider
                  name="Password"
                  rules="required"
                  v-slot="{ errors }">
                  <label class="text-body2" @click="showHidePass()">Password</label>
                  <c-input-group size="md">
                    <c-input
                      pr="4.5rem"
                      :type="show ? 'text' : 'password'"
                      placeholder="Password"
                      class="mt-1"
                      focus-border-color="primary"
                      v-model="password"
                      @click="showHidePass()" />
                    <c-input-right-element width="4.5rem">
                      <font-awesome-icon
                        class="cursor-pointer"
                        :icon="['fas', 'eye']"
                        @click="showHidePass()"
                        v-if="show" />
                      <font-awesome-icon
                        class="cursor-pointer"
                        :icon="['fas', 'eye-slash']"
                        @click="showHidePass()"
                        v-else />
                    </c-input-right-element>
                  </c-input-group>
                  <span class="text-error">{{ errors[0] }}</span>
                </ValidationProvider>
              </div>
              <div>
                <div class="w-full flex justify-center">
                  <c-button
                    variant-color="green"
                    class="rounded-full"
                    type="submit">Masuk</c-button>
                </div>
                <div class="mt-10">
                  <p class="text-center text-sm">Don't have an account? <b class="cursor-pointer">Sign Up</b></p>
                </div>
              </div>
            </form>
          </ValidationObserver>
        </div>
      </div>
    </div>
  </CThemeProvider>
</template>

<script>
import {
  authUseCase
} from '~/domain/usecase'
import moment from 'moment'

export default {
  name: 'LoginIndex',
  data() {
    return {
      username: 'admin',
      password: '123456',
      show: false

    }
  },
  methods: {
    showHidePass() {
      this.show = !this.show
    },
    processSubmit() {
      authUseCase.loginProcess(this.username, this.password).then(async (res) => {
        console.log('apaka', res)
        if (!res.error) {
          await this.$store.dispatch('setAppActiveUser', res.result)
          await this.$store.dispatch('setDateAuth', moment().format())
          await this.$store.dispatch('setIsAuth', true)
          window.location.href = '/e-wadol/dashboard'
        } else {
          this.$toast({
            // title: 'Account created.',
            description: res.message,
            status: 'error',
            duration: 3000
          })

        }
      })
    },
    submit() {
      this.$refs.form.validate().then((success) => {
        if (success) {
          this.processSubmit()
        }
      })
    }
  }
}
</script>

<style src="~/assets/styles/scss/layout/login.scss" lang="scss"></style>
