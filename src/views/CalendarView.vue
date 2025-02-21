<template>
  <div>
    <h1>Afsprong Availability Checker</h1>
    <DatePicker @date-selected="checkAvailability" />
    <div v-if="loading">Checking availability...</div>
    <div v-if="availability !== null">
      <p v-if="availability">The selected date is available.</p>
      <p v-else>The selected date is not available.</p>
    </div>
  </div>
</template>

<script>
import DatePicker from "../components/DatePicker.vue";

export default {
  components: {
    DatePicker,
  },
  data() {
    return {
      availability: null,
      loading: false,
    };
  },
  methods: {
    async checkAvailability(selectedDate) {
      console.log(`Checking availability for date: ${selectedDate}`);
      this.loading = true;
      try {
        const isAvailable = await this.$refs.datePicker.checkDateWithGoogleCalendar(selectedDate);
        this.availability = isAvailable;
      } catch (error) {
        console.error("Error checking availability:", error);
        this.availability = false;
      } finally {
        this.loading = false;
      }
    },
  },
};
</script>

<style scoped>
h1 {
  margin-bottom: 20px;
}
</style>
