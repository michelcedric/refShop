<template>
  <nav-menu></nav-menu>
  <router-view />
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import Home from './components/Home.vue';
import NavMenu from './components/NavMenu.vue';

@Options({
  components: {
    Home,
    NavMenu
  },
})
export default class App extends Vue {

}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
