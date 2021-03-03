<template>
  <nav class="navbar navbar-primary bg-primary sticky-top justify-content-between">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <h1 class="text-secondary border border-lg border-secondary px-2">
          K
        </h1>
      </div>
    </router-link>
    <form class="form-inline">
      <div class="input-group align-items-center">
        <input v-model="state.query" class="form-control" type="search" placeholder="Search" aria-label="Search">
        <div class="input-group-append">
          <button class="btn bg-white text-primary btn-outline-primary my-2 my-sm-0" type="submit">
            <i class="fa fa-search" aria-hidden="true"></i>
          </button>
        </div>
      </div>
    </form>

    <button
      class="navbar-toggler btn btn-outline-secondary text-uppercase"
      data-toggle="collapse"
      data-target="#navbarToggler"
      @click="login"
      v-if="!user.isAuthenticated"
    >
      Login
    </button>

    <div v-else
         class="navbar-toggler bg-secondary p-1"
         data-toggle="collapse"
         data-target="#navbarToggler"
    >
      <router-link :to="{ name: 'Profile', params: {id: state.account.id}}">
        <img
          :src="user.picture"
          alt="user photo"
          height="50"
          class="rounded-circle"
        />
        <span class="mx-3 text-white">{{ user.name }}</span>
      </router-link>
      <!-- <div
            class="list-group-item list-group-item-action hoverable"
            @click="logout"
          >
            logout
          </div> -->
    </div>
    <div class="collapse navbar-collapse" id="navbarToggler">
      <button
        class="btn btn-outline-secondary text-uppercase"
        @click="login"
        v-if="!user.isAuthenticated"
      >
        Login
      </button>

      <div v-else class="bg-secondary p-1">
        <router-link :to="{ name: 'Profile', params: {id: state.account.id}}">
          <img
            :src="user.picture"
            alt="user photo"
            height="50"
            class="rounded-circle"
          />
        </router-link>
      <!-- <div
            class="list-group-item list-group-item-action hoverable"
            @click="logout"
          >
            logout
          </div> -->
      </div>
    </div>
  </nav>
</template>

<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed, reactive, watchEffect } from 'vue'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'Navbar',
  setup() {
    const state = reactive({
      account: computed(() => AppState.account),
      query: ''
    })
    watchEffect(() => { if (state.query !== '') { keepsService.getAllKeeps(state.query) } })
    return {
      state,
      user: computed(() => AppState.user),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        await AuthService.logout({ returnTo: window.location.origin })
      }
    }
  }
}
</script>

<style scoped>
.dropdown-menu {
  user-select: none;
  display: block;
  transform: scale(0);
  transition: all 0.15s linear;
}
.dropdown-menu.show {
  transform: scale(1);
}
.hoverable {
  cursor: pointer;
}
a:hover {
  text-decoration: none;
}
.nav-link{
  text-transform: uppercase;
}
.nav-item .nav-link.router-link-exact-active{
  color: var(--secondary);
}
</style>
