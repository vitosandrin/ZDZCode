<template>
  <div class="flex justify-center items-center h-screen relative bg-gray-900">
    <CenterButtons @openModal="openModal" />

    <CreateTransactionModal
      v-if="modals.deposit"
      :visible="modals.deposit"
      title="Enviar Depósito"
      placeholder="Valor do Depósito"
      submitText="Enviar"
      submitClass="bg-green-500 text-white hover:bg-green-400"
      @submit="handleDeposit"
      @close-modal="closeModal('deposit')"
    />

    <CreateTransactionModal
      v-if="modals.withdraw"
      :visible="modals.withdraw"
      title="Sacar Dinheiro"
      placeholder="Valor do Saque"
      submitText="Sacar"
      submitClass="bg-red-500 text-white hover:bg-red-400"
      @submit="handleWithdraw"
      @close-modal="closeModal('withdraw')"
    />

    <AccountStatement :account="account" />
  </div>
</template>


<script setup lang="ts">
import { ref } from 'vue';
import { useRoute } from 'vue-router';
import CenterButtons from "@/components/CenterButtons.vue";
import CreateTransactionModal from "@/components/form/CreateTransactionModal.vue";
import AccountStatement from "@/components/AccountStatement.vue";
import { type Account } from "@/types/types";

export interface Modals {
  deposit: boolean;
  withdraw: boolean;
}

const { accountNumber } = useRoute().params;

const modals = ref<Modals>({
  deposit: false,
  withdraw: false,
});

const account = ref<Account>();

const fetchAccountData = async () => {
  const response = await useFetch<Account>(`https://localhost:7185/api/account/${accountNumber}`);
    account.value = response.data.value as Account;
};

await fetchAccountData();

const openModal = (modal: keyof Modals) => {
  modals.value[modal] = true;
};

const closeModal = (modal: keyof Modals) => {
  modals.value[modal] = false;
};

const handleDeposit = async ({ amount }: { amount: number }) => {
  await useFetch('https://localhost:7185/api/transaction/deposit', {
    method: 'POST',
    body: { amount, accountId: account.value?.id },
  });

  await fetchAccountData();
  closeModal("deposit");
};

const handleWithdraw = async ({ amount }: { amount: number }) => {
  await useFetch('https://localhost:7185/api/transaction/withdraw', {
    method: 'POST',
    body: { amount, accountId: account.value?.id },
  });

  await fetchAccountData();
  closeModal("withdraw");
};

useSeoMeta({
  title: "TestBank - Account",
});
</script>

<style scoped>
</style>
