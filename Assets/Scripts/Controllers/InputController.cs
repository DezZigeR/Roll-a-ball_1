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
        
        public InputController(PlayerBase player)
        {
            _playerBase = player;
            
            _saveDataRepository = new SaveDataRepository();
            _repository = new Repository();
            new ControllerTest1(_repository);
            new ControllerTest2(_repository);
        }

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(_savePlayer))
            {
                _saveDataRepository.Save(_playerBase);
            }
            if (Input.GetKeyDown(_loadPlayer))
            {
                _saveDataRepository.Load(_playerBase);
            }
        }
    }
}
