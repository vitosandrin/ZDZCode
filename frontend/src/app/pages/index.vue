<template>
  <div class="flex flex-col items-center justify-center h-screen bg-gray-800 text-white space-y-4">
    <button class="px-6 py-3 bg-blue-500 text-white rounded hover:bg-blue-400" @click="openModal('createAccount')">
      Criar Conta
    </button>
    <button class="px-6 py-3 bg-green-500 text-white rounded hover:bg-green-400" @click="openModal('accessAccount')">
      Acessar Conta
    </button>

    <CreateAccountModal v-if="modals.createAccount" :visible="modals.createAccount" title="Criar Conta"
      submitText="Criar" @submit="handleCreateAccount" @close-modal="closeModal('createAccount')" />
    <AccessAccountModal v-if="modals.accessAccount" :visible="modals.accessAccount" title="Acessar Conta"
      submitText="Acessar" @submit="handleAccessAccount" @close-modal="closeModal('accessAccount')" />
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import CreateAccountModal from "@/components/form/CreateAccountModal.vue";
import AccessAccountModal from "@/components/form/AccessAccountModal.vue";
import { type AccountData } from "@/types/types";

interface Modals {
  createAccount: boolean;
  accessAccount: boolean;
}

const modals = ref<Modals>({
  createAccount: false,
  accessAccount: false,
});

const router = useRouter();

const openModal = (modal: keyof Modals) => {
  modals.value[modal] = true;
};

const closeModal = (modal: keyof Modals) => {
  modals.value[modal] = false;
};

const handleCreateAccount = async ({ accountNumber, initialDeposit }: AccountData) => {
  const { error } = await useFetch('https://localhost:7185/api/account', {
    method: 'POST',
    body: { accountNumber, initialDeposit },
  });

  if (!error.value) {
    router.push(`/account/${accountNumber}`);
    closeModal("createAccount");
  }
};

const handleAccessAccount = async (accountNumber: string) => {
  router.push(`/account/${accountNumber}`);
  closeModal("accessAccount");
};

useSeoMeta({
  title: "TestBank",
});
</script>

<style scoped></style>
