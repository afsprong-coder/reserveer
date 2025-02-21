<template>
  <div id="app">
    <CalendarView />
  </div>
</template>

<script>
import CalendarView from './views/CalendarView.vue';

export default {
  name: 'App',
  components: {
    CalendarView
  }
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