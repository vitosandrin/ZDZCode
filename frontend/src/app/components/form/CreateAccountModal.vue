<template>
  <div class="modal" v-if="visible">
    <div class="modal-content p-6 bg-gray-800 text-white rounded-lg shadow-lg w-full max-w-md">
      <h2 class="text-xl font-semibold mb-6">{{ title }}</h2>

      <form @submit.prevent="handleSubmit">
        <div class="space-y-6">
          <div>
            <label for="accountNumber" class="block text-sm font-medium text-gray-300">
              Número da Conta
            </label>
            <input
              id="accountNumber"
              v-model="accountNumber"
              type="text"
              class="mt-2 text-black block w-full px-4 py-2 border border-gray-600 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500"
              placeholder="Insira o número da conta"
            />
          </div>

          <div>
            <label for="initialDeposit" class="block text-sm font-medium text-gray-300">
              Depósito Inicial
            </label>
            <input
              id="initialDeposit"
              v-model="initialDeposit"
              type="number"
              class="mt-2 text-black block w-full px-4 py-2 border border-gray-600 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500"
              placeholder="Insira o depósito inicial"
            />
          </div>
        </div>

        <div class="flex justify-end mt-6 space-x-4">
          <button
            type="button"
            @click="$emit('close-modal')"
            class="px-6 py-2 bg-gray-600 text-white rounded-lg hover:bg-gray-500 transition"
          >
            Cancelar
          </button>
          <button
            type="submit"
            class="px-6 py-2 bg-blue-500 text-white rounded-lg hover:bg-blue-400 transition"
          >
            {{ submitText }}
          </button>
        </div>
      </form>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { defineProps, defineEmits, ref } from 'vue';

interface SubmitPayload {
  accountNumber: string;
  initialDeposit: number;
}

defineProps<{
  visible: boolean;
  title: string;
  submitText?: string;
}>();

const emit = defineEmits<{
  (e: 'submit', payload: SubmitPayload): void;
  (e: 'close-modal'): void;
}>();

const accountNumber = ref<string>('');
const initialDeposit = ref<number>(0);

const handleSubmit = () => {
  emit('submit', {
    accountNumber: accountNumber.value,
    initialDeposit: initialDeposit.value,
  });
};
</script>

<style scoped>
.modal {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
}

.modal-content {
  width: 100%;
  max-width: 450px;
}
</style>
