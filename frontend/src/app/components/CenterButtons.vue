<template>
    <div class="flex justify-center space-x-4">
      <button
        class="bg-green-500 text-white px-6 py-3 rounded-lg shadow-md hover:bg-green-400 transition duration-300"
        @click="$emit('open-modal', 'deposit')"
      >
        Enviar Depósito
      </button>
      <button
        class="bg-red-500 text-white px-6 py-3 rounded-lg shadow-md hover:bg-red-400 transition duration-300"
        @click="$emit('open-modal', 'withdraw')"
      >
        Sacar Dinheiro
      </button>
    </div>
  </template>
  
  <script setup lang="ts">
  </script>
  