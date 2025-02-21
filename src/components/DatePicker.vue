<template>
  <div>
    <input type="date" v-model="selectedDate" @change="onDateChange" />
    <p v-if="availabilityMessage">{{ availabilityMessage }}</p>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      selectedDate: "",
      availabilityMessage: "",
    };
  },
  methods: {
    async onDateChange() {
      if (!this.selectedDate) return;
      this.$emit("date-selected", this.selectedDate);
    },
    async checkDateWithGoogleCalendar(date) {
      try {
        const response = await axios.get(`http://localhost:3000/check-availability?date=${date}`);
        return response.data.available;
      } catch (error) {
        console.error("Error checking availability:", error);
        return false;
      }
    },
  },
};
</script>

<style scoped>
input[type="date"] {
  padding: 10px;
  font-size: 16px;
}
</style>
