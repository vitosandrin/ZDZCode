<template>
    <div v-if="visible" class="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center z-50">
      <div class="bg-white p-6 rounded-lg shadow-lg w-96">
        <h2 class="text-xl font-semibold mb-4">{{ title }}</h2>
        <input
          v-model="inputValue"
          type="number"
          :placeholder="placeholder"
          class="w-full p-3 border border-gray-300 rounded-lg mb-4 focus:outline-none"
        />
        <div class="flex justify-between">
          <button
            @click="onSubmit"
            class="px-6 py-2 rounded-lg shadow-md transition duration-300"
            :class="submitClass"
          >
            {{ submitText }}
          </button>
          <button
            @click="$emit('close-modal')"
            class="bg-gray-300 text-gray-700 px-6 py-2 rounded-lg shadow-md hover:bg-gray-200 transition duration-300"
          >
            Fechar
          </button>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: "Modal",
    props: {
      visible: { type: Boolean, required: true },
      title: { type: String, required: true },
      placeholder: { type: String, required: true },
      submitText: { type: String, required: true },
      submitClass: { type: String, required: true },
    },
    data() {
      return {
        inputValue: 0,
      };
    },
    methods: {
      onSubmit() {
        this.$emit("submit", this.inputValue);
        this.inputValue = 0;
      },
    },
  };
  </script>
  