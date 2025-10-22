<script setup>
import { ref, watch } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';

const theme = ref(loadState('theme') || 'light')

function toggleTheme() {
  theme.value = theme.value == 'light' ? 'dark' : 'light'
}

watch(theme, () => {
  document.documentElement.setAttribute('data-bs-theme', theme.value)
  saveState('theme', theme.value)
}, { immediate: true })

</script>

<template>
  <div class="row  sahitya-regular allSpice position-relative">
    <div class="text-end">
      <Login />
    </div>
    <div class="d-flex flex-column justify-content-center align-items-center font-spice text-white">
      <h1 class="">All-Spice</h1>
      <p>Cherish Your Family</p>
      <p>And Their Cooking</p>
    </div>
    <!-- Starting tabs -->
    <div
      class="col-3 d-flex flex-row justify-content-center align-items-center sahitya-regular absolute gap-3 text-green align-self-end rounded">
      <RouterLink :to="{ name: 'Home' }">
        <p>Home</p>
      </RouterLink>
      <RouterLink :to="{ name: 'My Recipes' }">
        <p>My Recipes</p>
      </RouterLink>
      <RouterLink :to="{ name: 'Favorites' }">
        <p>Favorites</p>
      </RouterLink>
    </div>
  </div>

  <nav class="navbar navbar-expand-md ">


    <div class="container gap-2">
      <!-- collapse button -->
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbar-links"
        aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
        <span class="mdi mdi-menu text-light"></span>
      </button>
      <!-- collapsing menu -->
      <div class="collapse navbar-collapse " id="navbar-links">

        <!-- LOGIN COMPONENT HERE -->
        <div class="ms-auto">
        </div>
      </div>
    </div>
  </nav>
</template>

<style lang="scss" scoped>
a {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

.allSpice {
  background-image: url(https://images.unsplash.com/photo-1509358271058-acd22cc93898?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&q=80&w=1740);
  min-height: 500px;
  width: 100%;
  background-size: cover;
  background-position: center;
  margin: 0;
}

.font-spice {
  text-shadow: 0 0 10px black, 1px 2px 3px black;
}

.absolute {
  position: absolute;
  left: 74vh;
  bottom: -6%;
  min-height: 60px;
  background-color: white;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.488)
}
</style>
