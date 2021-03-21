using Geekbrains.NewDirectory1;
using UnityEngine;

namespace Geekbrains
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;
        private readonly Repository _repository;
        private readonly SaveGoodDataRepository _saveGoodDataRepository;
        private readonly SaveBadDataRepository _saveBadDataRepository;

        public InputController(PlayerBase player)
        {
            _playerBase = player;
            
            _saveDataRepository = new SaveDataRepository();
            _repository = new Repository();
            new ControllerTest1(_repository);
            new ControllerTest2(_repository);
            _saveGoodDataRepository = new SaveGoodDataRepository();
            _saveBadDataRepository = new SaveBadDataRepository();
        }

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(_savePlayer))
            {
                _interactiveObject = new ListExecuteObject();
                int goodBonusNumber = 0;
                int bedBonusNumber = 0;
                foreach (var o in _interactiveObject)
                {
                    if (o is GoodBonus goodBonus)
                    {
                        //Debug.Log(goodBonus.name + goodBonusNumber);
                        _saveGoodDataRepository.Save(goodBonus, goodBonusNumber);
                        goodBonusNumber += 1;
                    }
                    if (o is BadBonus badBonus) //добить
                    {
                        //Debug.Log(badBonus.name + bedBonusNumber);
                        _saveBadDataRepository.Save(badBonus, bedBonusNumber);
                        bedBonusNumber += 1;
                    }
                    _saveDataRepository.Save(_playerBase);
                }
            }
            if (Input.GetKeyDown(_loadPlayer))
            {
                _interactiveObject = new ListExecuteObject();
                int goodBonusNumber = 0;
                int badBonusNumber = 0;
                foreach (var o in _interactiveObject)
                {
                    if (o is GoodBonus goodBonus)
                    {
                        //Debug.Log(goodBonus.name + goodBonusNumber);
                        _saveGoodDataRepository.Load(goodBonus, goodBonusNumber);
                        goodBonusNumber += 1;
                    }
                    if (o is BadBonus badBonus) //добить
                    {
                        _saveBadDataRepository.Load(badBonus, badBonusNumber);
                        goodBonusNumber += 1;

                    }
                    _saveDataRepository.Load(_playerBase);
                }
            }
        }
    }

}
