mergeInto(LibraryManager.library, {

  ShowFullscreen: function () {
      ysdk.adv.showFullscreenAdv({
      callbacks: {
          onOpen: function(wasShown) {
            console.log('Реклама Fullscreen открылась.');
          },
          onClose: function(wasShown) {
            console.log("Реклама Fullscreen закрылась.");
          },
          onError: function(error) {
            console.log("Ошибка по рекламе Fullscreen.");
          }
      }
      })
  },

  ShowRewarded: function () {
      ysdk.adv.showRewardedVideo({
      callbacks: {
          onOpen: () => {
            console.log('Реклама Rewarded открылась.');
          },
          onRewarded: () => {
            console.log('Реклама Rewarded просмотрена, и производим награду игроку за просмотр.');
            myGameInstance.SendMessage("StartAds", "AdsCoints");
          },
          onClose: () => {
            console.log('Реклама Rewarded закрылась.');
          }, 
          onError: (e) => {
            console.log('Ошибка по рекламе Rewarded:', e);
          }
      }
  })
  },

  GetLang: function (){
      ysdk.invironment.i18n.lang;
      console.log(ysdk.invironment.i18n.lang);
  },

  LoadingAPIReady: function(){
      console.log("--------Podkluchaem API--------");
      ysdk.features.LoadingAPI.ready();
      console.log("--------Podkluchili API--------");
  },

      GameplayAPIStart: function(){
      ysdk.features.GameplayAPI.start()
      console.log("--------Start API--------");
  },

      GameplayAPIStop: function(){
      ysdk.features.GameplayAPI.stop()
      console.log("--------Stop API--------");
  },


});
