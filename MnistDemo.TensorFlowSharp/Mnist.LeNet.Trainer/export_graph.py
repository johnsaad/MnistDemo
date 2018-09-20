from __future__ import absolute_import
from __future__ import division
from __future__ import print_function

import argparse
import tensorflow as tf

from tensorflow.python.tools.freeze_graph import freeze_graph_with_def_protos


def export(args):
    ckpt = tf.train.get_checkpoint_state(args.model_dir)
    if ckpt and ckpt.model_checkpoint_path:
        _ = tf.train.import_meta_graph(ckpt.model_checkpoint_path + '.meta'  )
        input_graph_def = tf.get_default_graph().as_graph_def()
        freeze_graph_with_def_protos(input_graph_def=input_graph_def,
                                     input_saver_def=None,
                                     input_checkpoint=ckpt.model_checkpoint_path,
                                     output_node_names=args.predict_node,
                                     restore_op_name='', # Unused
                                     filename_tensor_name='', # Unused
                                     output_graph=args.output_pb,
                                     clear_devices=True,
                                     initializer_nodes=None)
    else:
        raise FileNotFoundError('Cannot find valid checkpoint from %s' % args.model_dir)


if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument('--model_dir', type=str, default='model',
                        help='TensorFlow checkpoint directory to load.')
    parser.add_argument('--output_pb', type=str, default='mnist.pb',
                        help='Output GraphDef file name.')
    parser.add_argument('--predict_node', type=str, default='Predict',
                        help='The name of the output nodes, comma separated.')
    args, unknown = parser.parse_known_args()
    export(args)