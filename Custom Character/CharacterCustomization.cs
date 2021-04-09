using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets._Scripts.Custom_Character
{
    public class CharacterCustomization : MonoBehaviour
    {
        public GameObject target;
        public string suffixMax = "Max", suffixMin = "Min";
        private CharacterCustomization() { }
        private SkinnedMeshRenderer skmr;
        private Mesh mesh;

        private IDictionary<string, BlendShape> blendShapeDatabase = new Dictionary<string, BlendShape>();

        private void Start()
        {
            //Initialize()
        }

        #region Public Functions

        public void ChangeBlendshapeValue(string blendshapeName, float value)
        {
            if (!blendShapeDatabase.ContainsKey(blendshapeName)) { Debug.LogError("Blendshape " + blendshapeName + " does not exist!"); return; }

            value = Mathf.Clamp(value, -100, 100);

            BlendShape blendShape = blendShapeDatabase[blendshapeName];

            if (value >= 0)
            {
                if (blendShape.positiveIndex == -1) return;
                skmr.SetBlendShapeWeight(blendShape.positiveIndex, value);
                if (blendShape.negativeIndex == -1) return;
                skmr.SetBlendShapeWeight(blendShape.negativeIndex, 0);
            }

            else
            {
                if (blendShape.negativeIndex == -1) return;
                skmr.SetBlendShapeWeight(blendShape.negativeIndex, -value);
                if (blendShape.positiveIndex == -1) return;
                skmr.SetBlendShapeWeight(blendShape.positiveIndex, 0);
            }
        }

        #endregion

        #region Private Functions

        private void Initialize()
        {
            skmr = GetSkinnedMeshRenderer();
            mesh = skmr.sharedMesh;

            //setup database function
        }

        private SkinnedMeshRenderer GetSkinnedMeshRenderer()
        {
            SkinnedMeshRenderer _skmr = target.GetComponentInChildren<SkinnedMeshRenderer>();
            return _skmr;
        }

        private void ParseBlendShapesToDictionary()
        {
            List<string> blendshapesNames = Enumerable.Range(0, mesh.blendShapeCount).Select(x => mesh.GetBlendShapeName(x)).ToList();
            for (int i = 0; i < blendshapesNames.Count; i++)
            {
                string altSuffix, noSuffix;
                noSuffix = blendshapesNames[i].TrimEnd(suffixMax.ToCharArray()).TrimEnd(suffixMin.ToCharArray()).Trim();

                string positiveName = string.Empty, negativeName = string.Empty;
                bool exists = false;

                int positiveIndex = -1, negativeIndex = -1;

                //se o sufixo for positivo
                if (blendshapesNames[i].EndsWith(suffixMax))
                {
                    altSuffix = noSuffix + " " + suffixMax;

                    positiveName = blendshapesNames[i];
                    negativeName = altSuffix;

                    if (blendshapesNames.Contains(altSuffix)) exists = true;

                    positiveIndex = mesh.GetBlendShapeIndex(positiveName);

                    if (exists)
                    {
                        negativeIndex = mesh.GetBlendShapeIndex(altSuffix);
                    }
                }

                //se o sufixo for negativo
                else if (blendshapesNames[i].EndsWith(suffixMin))
                {
                    altSuffix = noSuffix + " " + suffixMin;

                    negativeName = blendshapesNames[i];
                    positiveName = altSuffix;

                    if (blendshapesNames.Contains(altSuffix)) exists = true;

                    negativeIndex = mesh.GetBlendShapeIndex(negativeName);

                    if (exists)
                    {
                        positiveIndex = mesh.GetBlendShapeIndex(altSuffix);
                    }
                }
                else
                {
                    positiveIndex = mesh.GetBlendShapeIndex(blendshapesNames[i]);
                }

                blendShapeDatabase.Add(noSuffix, new BlendShape(positiveIndex, negativeIndex));

                //remove os índices selecionados da lista
                if (positiveName != string.Empty) blendshapesNames.Remove(positiveName);
                if (negativeName != string.Empty) blendshapesNames.Remove(negativeName);
            }
        } // End of Class

        #endregion
    }
}